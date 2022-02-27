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
                // GET: TodoItem���X�g�̓ǂݍ���
                var todoItems = await WebApiClient.GetTodoItemsAsync();

                todoItems?.ForEach(todoItem => _dispTodoItems.Add(todoItem));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show("Todo���擾�ł��܂���ł����B");
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                // �쐬�̏ꍇ
                using (var dialog = new TodoEditForm())
                {
                    dialog.TodoAdded += (o, te) => _dispTodoItems.Add(te.AddedItem);
                    // ��ʂ��N��
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
                // �I���s��TodoItem���擾
                var selectedItem = todoItemGridView.SelectedRows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem as TodoItem).SingleOrDefault();

                if (selectedItem != null)
                {
                    // �ҏW�̏ꍇ
                    using (var dialog = new TodoEditForm(selectedItem))
                    {
                        // ��ʂ��N��
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
            var result = MessageBox.Show("Todo���폜���܂����H", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            // �͂�: �폜����ꍇ
            if (result == DialogResult.Yes)
            {
                try
                {
                    // �I���s��TodoItem���擾
                    var selectedItem = todoItemGridView.SelectedRows.Cast<DataGridViewRow>().Select(r => r.DataBoundItem as TodoItem).SingleOrDefault();

                    if (selectedItem != null)
                    {
                        // DELETE: TodoItem�̍폜
                        var statusCode = await WebApiClient.DeleteTodoItemAsync(selectedItem.Id);
                        System.Diagnostics.Debug.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                        _dispTodoItems.Remove(selectedItem);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                    MessageBox.Show("Todo���폜�ł��܂���ł����B");
                }
            }
        }
    }
}