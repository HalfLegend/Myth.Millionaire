﻿using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Myth.Millionaire.Core.ViewModels {
    public class MainViewModel : MvxViewModel {
        public MainViewModel() {
        }

        public IMvxCommand ResetTextCommand => new MvxCommand(ResetText);
        private void ResetText() {
            Text = "Hello MvvmCross";
        }

        private string _text = "Hello MvvmCross";
        public string Text {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}