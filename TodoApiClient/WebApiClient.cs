using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TodoApi.Models;

namespace TodoApiClient
{
    public static class WebApiClient
    {
        private static HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("http://192.168.11.14:5000/")
        };

        private static void Init()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<TodoItem?> CreateTodoItemAsync(TodoItem item)
        {
            Init();

            HttpResponseMessage response = await _client.PostAsJsonAsync("api/todoitems", item);
            response.EnsureSuccessStatusCode();

            item = await response.Content.ReadAsAsync<TodoItem>();

            return item;
        }

        public static async Task<List<TodoItem>?> GetTodoItemsAsync()
        {
            Init();

            List<TodoItem>? todoItems = null;
            HttpResponseMessage response = await _client.GetAsync("api/todoitems");
            if (response.IsSuccessStatusCode)
            {
                todoItems = await response.Content.ReadAsAsync<List<TodoItem>>();
            }
            return todoItems?.OrderBy(item => item.Id).ToList();
        }

        public static async Task<TodoItem?> GetTodoItemAsync(long id)
        {
            Init();

            TodoItem? item = null;
            HttpResponseMessage response = await _client.GetAsync($"api/todoitems/{id}");
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<TodoItem>();
            }

            return item;
        }

        public static async Task<TodoItem> UpdateTodoItemAsync(TodoItem item)
        {
            Init();

            HttpResponseMessage response = await _client.PutAsJsonAsync($"api/todoitems/{item.Id}", item);
            response.EnsureSuccessStatusCode();

            item = await response.Content.ReadAsAsync<TodoItem>();

            return item;
        }

        public static async Task<HttpStatusCode> DeleteTodoItemAsync(long id)
        {
            Init();

            HttpResponseMessage response = await _client.DeleteAsync($"api/todoitems/{id}");
            return response.StatusCode;
        }
    }
}
