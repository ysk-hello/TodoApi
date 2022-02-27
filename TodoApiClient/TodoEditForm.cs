using TodoApi.Models;

namespace TodoApiClient
{
    public partial class TodoEditForm : Form
    {
        private TodoItem _todoItem = new TodoItem();

        public event Action<object, TodoAddedEventArgs>? TodoAdded;

        public TodoEditForm(TodoItem? item = null)
        {
            InitializeComponent();

            if (item != null)
            {
                // 編集の場合

                // Idを表示
                idLabel.Visible = idValueLabel.Visible = true;
                _todoItem = item;
            }

            // バインド
            idValueLabel.DataBindings.Add(nameof(idValueLabel.Text), _todoItem, nameof(_todoItem.Id));
            nameTextBox.DataBindings.Add(nameof(nameTextBox.Text), _todoItem, nameof(_todoItem.Name));
            doneCheckBox.DataBindings.Add(nameof(doneCheckBox.Checked), _todoItem, nameof(_todoItem.IsComplete));
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                // GET: TodoItemの読み込み
                var target = await WebApiClient.GetTodoItemAsync(_todoItem.Id);

                if (target == null)
                {
                    // 作成の場合

                    // POST: TodoItemの追加
                    var item = await WebApiClient.CreateTodoItemAsync(_todoItem);

                    if (item != null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Created at {item.Id}");

                        if (TodoAdded != null)
                        {
                            // 追加イベントの発生
                            TodoAdded(this, new TodoAddedEventArgs(item));
                        }
                    }
                }
                else
                {
                    // 編集の場合

                    // PUT: TodoItemの変更
                    await WebApiClient.UpdateTodoItemAsync(_todoItem);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
    }
}
