using System.Collections.ObjectModel;
using Finanzas1.Models;
using Finanzas1.Services;

namespace Finanzas1.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ITransactionService _service;

        public ObservableCollection<Transaction> Transactions { get; } = new();

        private Transaction? _selected;
        public Transaction? Selected
        {
            get => _selected;
            set { _selected = value; OnPropertyChanged(); }
        }

        public RelayCommand RefreshCommand { get; }
        public RelayCommand AddCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public MainViewModel(ITransactionService service)
        {
            _service = service;

            RefreshCommand = new RelayCommand(async () => await LoadAsync());
            AddCommand = new RelayCommand(async () =>
            {
                var item = new Transaction { Description = "New item", Amount = 0m, Category = "General" };
                await _service.AddAsync(item);
                await LoadAsync();
                Selected = Transactions.FirstOrDefault(t => t.Id == item.Id);
            });

            UpdateCommand = new RelayCommand(async () =>
            {
                if (Selected is null) return;
                await _service.UpdateAsync(Selected);
                await LoadAsync();
            }, () => Selected is not null);

            DeleteCommand = new RelayCommand(async () =>
            {
                if (Selected is null) return;
                await _service.DeleteAsync(Selected.Id);
                await LoadAsync();
            }, () => Selected is not null);
        }

        public async Task LoadAsync()
        {
            Transactions.Clear();
            var items = await _service.GetAllAsync();
            foreach (var item in items) Transactions.Add(item);
        }
    }
}
