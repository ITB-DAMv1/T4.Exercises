using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.Activities.Tools
{
	public class DateTimeTools
	{
		public static DateTime? InputUserData()
		{
			DateTime data;
			bool isError = true;
			while (isError)
			{
				try
				{
					Console.Write($"\n{missatge}: ");
					string entrada = Console.ReadLine();

					// Intentem convertir la cadena a DateTime amb el format correcte
					data = DateTime.ParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture);

					return data; //Retornem la data si és vàlida
				}
				catch (FormatException)
				{
					Console.WriteLine("Format incorrecte! Escriu la data en format dd/mm/yyyy.");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error inesperat: {ex.Message}");
				}
			}

			return null;
		}
	}
}
