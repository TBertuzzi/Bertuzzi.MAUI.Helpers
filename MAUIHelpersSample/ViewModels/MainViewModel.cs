using MAUIHelpersSample.Services;
using MAUIHelpersSample.ViewModels.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUIHelpersSample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public ObservableCollection<MyTodo> Todos { get; }

        public MainViewModel()
        {
            Todos = new ObservableCollection<MyTodo>();

            LoadTodo();

        }

        private async void LoadTodo()
        {
            SampleService sampleService = new SampleService();

            //Set Timeout on task
            var todosResult = await sampleService.GetTodos().WithTimeout(5000);

            foreach (var todo in todosResult)
            {
                //Cast Extension
                Todos.Add(todo.Cast<MyTodo>());
            }
        }
    }
}
