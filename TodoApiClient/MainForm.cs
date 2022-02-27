using System.ComponentModel;
using TodoApi.Models;

namespace TodoApiClient
{
    public partial class MainForm : Form
    {
        private BindingList<TodoItem> _dispTodoItems = new BindingList<TodoItem>();

        public MainForm()
        {
            InitializeComponent();

            todoItemGridView.DataSource = _dispTodoItems;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // GET: TodoItemリストの読み込み
                var todoItems = await WebApiClient.GetTodoItemsAsync();

                todoItems?.ForEach(todoItem => _dispTodoItems.Add(todoItem));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show("Todoを取得できませんでした。");
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 作成の場合
                using (var dialog = new TodoEditForm())
                {
                    dialog.TodoAdded += (o, te) => _dispTodoItems.Add(te.AddedItem);
                    // 画面を起動
                    dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 選択行のTodoItemを取得
                var selectedItem = todoItemGridView.SelectedRows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem as TodoItem).SingleOrDefault();

                if (selectedItem != null)
                {
                    // 編集の場合
                    using (var dialog = new TodoEditForm(selectedItem))
                    {
                        // 画面を起動
                        dialog.ShowDialog();
                        todoItemGridView.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Todoを削除しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            // はい: 削除する場合
            if (result == DialogResult.Yes)
            {
                try
                {
                    // 選択行のTodoItemを取得
                    var selectedItem = todoItemGridView.SelectedRows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem as TodoItem).SingleOrDefault();

                    if (selectedItem != null)
                    {
                        // DELETE: TodoItemの削除
                        var statusCode = await WebApiClient.DeleteTodoItemAsync(selectedItem.Id);
                        System.Diagnostics.Debug.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                        _dispTodoItems.Remove(selectedItem);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    MessageBox.Show("Todoを削除できませんでした。");
                }
            }
        }
    }
}