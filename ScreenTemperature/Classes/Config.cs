﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScreenTemperature.Classes
{
    [Serializable]
    public class Config : INotifyPropertyChanged
    {
        #region Variables

        private string _configName;
        private int _order;
        private string _configPath;
        private KeyData _keyBinding;
        private List<Monitor> _monitors;

        #endregion

        #region Properties

        public string ConfigName
        {
            get => _configName;
            set
            {
                _configName = value;
                NotifyPropertyChanged("Libelle");
            }
        }

        public int Order
        {
            get => _order;
            set
            {
                _order = value;
                NotifyPropertyChanged("Order");
            }
        }

        public string ConfigPath
        {
            get => _configPath;
            set
            {
                _configPath = value;
                NotifyPropertyChanged("ConfigPath");
            }
        }

        public KeyData KeyBinding
        {
            get => _keyBinding;
            set
            {
                _keyBinding = value;
                NotifyPropertyChanged("KeyBinding");
            }
        }

        public List<Monitor> Monitors
        {
            get => _monitors;
            set
            {
                _monitors = value;
                NotifyPropertyChanged("Monitor");
            }
        }

        #endregion

        #region Methods

        #region Implementation INotifyPropertyChanged

        //INotifyPropertyChanged implementation
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public override string ToString()
        {
            return ConfigName;
        }

        #endregion
    }
}