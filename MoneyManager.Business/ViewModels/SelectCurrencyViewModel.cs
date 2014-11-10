﻿using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using MoneyManager.Business.Logic;
using MoneyManager.DataAccess.DataAccess;
using MoneyManager.Foundation;
using MoneyManager.Foundation.Model;
using PropertyChanged;

namespace MoneyManager.Business.ViewModels
{
    [ImplementPropertyChanged]
    public class SelectCurrencyViewModel : ViewModelBase
    {
        public ObservableCollection<Country> AllCountries { get; set; }

        public InvocationType InvocationType { get;set; }

        public Country SelectedCountry
        {
            set
            {
                if (value == null) return;

                SetValue(value);
                ((Frame)Window.Current.Content).GoBack();
            }
        }

        private void SetValue(Country value)
        {
            switch (InvocationType)
            {
                case InvocationType.Setting:
                    RegionLogic.SetNewCurrency(value.CurrencyID);
                    break;
                case InvocationType.Transaction:
                    ServiceLocator.Current.GetInstance<AddTransactionViewModel>().SetCurrency(value.CurrencyID);
                    break;
                case InvocationType.Account:
                    ServiceLocator.Current.GetInstance<AddAccountViewModel>().SetCurrency(value.CurrencyID);
                    break;
            }
        }

        public async Task LoadCountries()
        {
            AllCountries = new ObservableCollection<Country>(await CurrencyLogic.GetSupportedCountries());
        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value.ToUpper();
                Search();
            }
        }

        public async void Search()
        {
            if (SearchText != String.Empty)
            {
                AllCountries =
                    new ObservableCollection<Country>(
                        AllCountries
                            .Where(x => x.ID.Contains(searchText) || x.CurrencyID.Contains(SearchText))
                            .ToList());
            }
            else
            {
                await LoadCountries();

            }
        }

    }
}
