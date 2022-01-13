using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Radio_Blue_Point.Models
{
	public class RecipeModel : INotifyPropertyChanged
	{
		private int _id;
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
				OnPropertyChanged(nameof(Id));
			}
		}
		private string _mail;
		[NotNull]
		public string Mail
		{
			get
			{
				return _mail;
			}
			set
			{
				this._mail = value;
				OnPropertyChanged(nameof(Mail));
			}
		}

		private string _password;
		[NotNull]
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				this._password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		private string _nome;
		[NotNull]
		public string Nome
		{
			get
			{
				return _nome;
			}
			set
			{
				this._nome = value;
				OnPropertyChanged(nameof(Nome));
			}
		}

		private string _cognome;
		[NotNull]
		public string Cognome
		{
			get
			{
				return _cognome;
			}
			set
			{
				this._cognome = value;
				OnPropertyChanged(nameof(Cognome));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this,
				new PropertyChangedEventArgs(propertyName));
		}
	}
}
