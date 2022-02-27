using TodoApi.Models;

namespace TodoApiClient
{
    public class TodoAddedEventArgs : EventArgs
    {
        public TodoAddedEventArgs(TodoItem item)
        {
            AddedItem = item;
        }

        public TodoItem AddedItem { get; }
    }
}
