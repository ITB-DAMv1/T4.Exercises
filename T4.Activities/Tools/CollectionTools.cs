using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.Activities.Tools
{
	public static class CollectionTools
	{

		/// <summary>
		/// Funció auxiliar per mostrar elements de col·leccio no generica
		/// </summary>
		/// <param name="llista"></param>
		public static void PrintCollection(IEnumerable llista)
		{
			foreach (var element in llista)
			{
				Console.Write(element + " | ");
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Funció auxiliar per mostrar elements d'una col·leccio generica
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="llista"></param>
		public static void PrintCollection<T>(IEnumerable<T> llista)
		{
			foreach (var element in llista)
			{
				Console.Write(element + " | ");
			}
			Console.WriteLine();
		}

		public static void PrintCollection<TKey, TValue>(Dictionary<TKey, TValue> dic)
		{
			foreach (var entrada in dic)
			{
				Console.WriteLine($"🔹 {entrada.Key} → {entrada.Value}");
			}
		}
		public static void PrintCollection<TKey, TValue>(Dictionary<TKey, TValue> dic, string valueMsg)
		{
			foreach (var entrada in dic)
			{
				Console.WriteLine($"🔹 {entrada.Key} → {entrada.Value} {valueMsg}");
			}
		}

		public static void PrintLineElements(IEnumerable ie, string delimiter)
		{
			Console.WriteLine(string.Join(delimiter, ie));
		}
		public static void PrintLineElements<T>(IEnumerable<T> ie, string delimiter)
		{
			Console.WriteLine(string.Join(delimiter, ie));
		}
	}
}
