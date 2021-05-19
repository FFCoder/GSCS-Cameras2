using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DTO;
using GSCS_Cameras_Server.Data;
using Microsoft.EntityFrameworkCore;

namespace GSCS_Cameras_Server.Services
{
    public class CameraService : IEntityService<Camera>
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient _client;
        public CameraService(ApplicationDbContext context, HttpClient client)
        {
            _context = context;
            _client = client;
        }
        public Camera Get(int id)
        {
            return _context.Cameras.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Camera> GetAsync(int id)
        {
            return await _context.Cameras.FirstOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Camera> GetAll()
        {
            return _context.Cameras.ToList();
        }

        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await _context.Cameras.ToListAsync();
        }

        public Camera Add(Camera item)
        {
            _context.Cameras.Add(item);
            _context.SaveChanges();
            return item;
        }

        public async Task<Camera> AddAsync(Camera item)
        {
            await _context.Cameras.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public void Remove(Camera item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }
        
        private static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private async Task<HttpResponseMessage> PerformWebRequest(string url, string username, string password)
        {
            var authString = "Basic " + Base64Encode($"{username}:{password}");
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get,
                Headers = { {HttpRequestHeader.Authorization.ToString(), authString}}
            };
            return await _client.SendAsync(request);
        }

        public bool OpenCamera(Camera camera)
        {
            return PerformWebRequest(camera.OpenLensUrl, camera.Username, camera.Password).Result.IsSuccessStatusCode;
        }

        public bool CloseCamera(Camera camera)
        {
            return PerformWebRequest(camera.CloseLensUrl, camera.Username, camera.Password).Result.IsSuccessStatusCode;
        }

        public async Task<string> GetStaticImageBase64Async(Camera c)
        {
            var result = await PerformWebRequest(c.StaticImageUrl, c.Username, c.Password);
            if (result.IsSuccessStatusCode)
            {
                var bytes = await result.Content.ReadAsByteArrayAsync();
                return "image/jpeg;base64," + Convert.ToBase64String(bytes);
                
            }
            
            throw new Exception("Unable to Get Static Image");
        }
        
        
    }
}