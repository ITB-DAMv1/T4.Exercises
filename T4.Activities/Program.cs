using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using T4.Activitats;
using T4.Activities.Tools;

internal class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("********** T4.Activitats **********");


		Console.WriteLine("*** T4.1");
		Ex1();
        Console.WriteLine("*** T4.2");
		Ex2();
		Console.WriteLine("*** T4.3");
		Ex3();
		Console.WriteLine("*** T4.5");
		Ex5();
		Console.WriteLine("*** T4.6");
		Ex6();
		Console.WriteLine("*** T4.7");
		Ex7();
		Console.WriteLine("*** T4.8");
		Ex8();
		Console.WriteLine("*** T4.9");
		Ex9();

		/*** Exercicis de Delegates al Repo de teoria del modul ***/

		Console.WriteLine("*** T4.14");
		Ex14();
		Console.WriteLine("*** T4.16");
		Ex16();
		Console.WriteLine("*** T4.18");
		Ex18();
		Console.WriteLine("*** T4.26");
		Ex26();
		Console.WriteLine("*** T4.28");
		Ex28();

	}

	public static void Ex1()
    {
        Pair<string, int> pair1 = new Pair<string, int>("Hola", 3);

        Console.WriteLine("Pair1 {0}", pair1.ToString());


        Pair<double, bool> pair2 = new Pair<double, bool>(3.5d, false);

        Console.WriteLine("Pair2 {0}", pair1.ToString());
    }

    public static void Ex2()
    {
        const string extiInput = "0Exit";
        string s;

        ArrayList arrayList = new ArrayList();

        Console.WriteLine("Afegeix valors al ArrayList. Per finalitzar escriu: {0}", extiInput);
        do
        {
            s = Console.ReadLine();
            arrayList.Add(s);
        } while (!string.Equals(s, extiInput) && s != "");

        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }
    }
    public static void Ex3()
    {
        const string extiInput = "0Exit";
        Dictionary<string, int> edats = new Dictionary<string, int>();
        string s;
        do
        {
            Console.WriteLine("Escriu Nom simple i edat separats per ','");
            s = Console.ReadLine();
            var sArray = s.Split(",");
            if (sArray.Length < 2 && !string.Equals(s, extiInput))
            {
                Console.WriteLine("Error de dades");
            }

        } while (!string.Equals(s, extiInput));
    }
	/// <summary>
	/// Exercice 5: Troba els nombres parells en una llista d'enters introduïts per teclat i mostra’ls per consola.
	/// </summary>
	public static void Ex5()
	{
		const string extiInput = "0Exit";
		Console.WriteLine("Introdueix una llista de nombres enters separats per espais:");
		string entrada = Console.ReadLine(); // Llegim l'entrada com a string

		// Convertim l'entrada en una llista d'enters
		List<int> nombres = entrada.Split(' ')
								   .Where(s => int.TryParse(s, out _)) // Filtra només els enters vàlids
								   .Select(int.Parse)
								   .ToList();

		// Filtrar nombres parells
		IEnumerable<int> parells = nombres.Where(n => n % 2 == 0).ToList();

		// Mostrar el resultat
		Console.WriteLine("Nombres parells:");
		Console.WriteLine(string.Join(", ", parells));

        //Console.WriteLine(parells.ElementAt<int>(0)); --> estara buida! Si vull treballar un altre cop, aquest IEnumarable ha de convertir-se en llista.

	}

	/// <summary>
	/// Calcula quants dies falten per a una data específica introduïda per teclat i mostra el resultat per consola .
	/// </summary>
	public static void Ex6()
    {
        DateTime dT;
        DateTime today = DateTime.Today;
        bool dateCorrect = false;
        IFormatProvider provider = CultureInfo.CurrentCulture;
        do
        {
            Console.WriteLine("Introdueix data dd/mm/yyyy");
            dateCorrect = DateTime.TryParse(Console.ReadLine(), provider, out dT);
            if (!dateCorrect) Console.WriteLine("Error de format");
            else
            {
                TimeSpan diferencia = dT - today;
                if (diferencia.Days < 0) 
                    Console.WriteLine("La data ja ha pasat");
                else
                    Console.WriteLine("Diferencia de dies: {0}", diferencia.Days);
            }
        } while (!dateCorrect);
    }

	/// <summary>
	///     Crea un programa que faci el següent:
    ///         Declari un ArrayList i hi afegeixi els següents elements: "Maria", "Joan", "Anna", 42, true.
    ///         Mostri tots els elements a la consola.
    ///         Elimini el número 42 i el valor true.
    ///         Insereixi "Pere" a la segona posició.
    ///         Comprovi si "Anna" està a la llista.
    ///         Converteixi l'ArrayList a un string[].
	/// </summary>
	public static void Ex7() {
		// 1️ Declarar un ArrayList i afegir elements
		ArrayList llista = new ArrayList { "Maria", "Joan", "Anna", 42, true };

		// 2️ Mostrar tots els elements
		Console.WriteLine("Llista original:");
		CollectionTools.PrintCollection(llista);

		// 3️ Eliminar el número 42 i el valor true
		llista.Remove(42);
		llista.Remove(true);
		Console.WriteLine("\nDespres d'eliminar 42 i true:");
		CollectionTools.PrintCollection(llista);

		// 4️ Inserir "Pere" a la segona posició (índex 1)
		llista.Insert(1, "Pere");
		Console.WriteLine("\nDespres d'inserir 'Pere' a la segona posicio:");
		CollectionTools.PrintCollection(llista);

		// 5️ Comprovar si "Anna" està a la llista
		bool contéAnna = llista.Contains("Anna");
		Console.WriteLine($"\nLa llista conte 'Anna'? {contéAnna}");

		// 6️ Convertir l'ArrayList a un string[]
		string[] array = llista.OfType<string>().ToArray();
		Console.WriteLine("\nArray de strings convertit:");
		Console.WriteLine(string.Join(", ", array));
	}

	/// <summary>
	/// Crea un programa que:
	///     Declari una List<int> amb els números[5, 10, 15, 20, 25].
    ///     Afegeixi 30 al final de la llista.
    ///     Insereixi 7 a la primera posició.
    ///     Elimini el número 15.
    ///     Ordeni la llista en ordre descendent.
    ///     Filtri els nombres parells i els mostri per pantalla
	/// </summary>
	public static void Ex8()
    {
		List<int> numeros = new List<int> { 5, 10, 15, 20, 25 };

		numeros.Add(30);

		numeros.Insert(0, 7);

		numeros.Remove(15);

		numeros.Sort();
		numeros.Reverse(); // Ordenar descendentment

		List<int> parells = numeros.Where(n => n % 2 == 0).ToList();

		// 🔹 Mostrar els resultats
		Console.WriteLine("Llista ordenada en ordre descendent:");
		Console.WriteLine(string.Join(", ", numeros));

		Console.WriteLine("\nNombres parells:");
	}

	/// <summary>
	/// Crea un programa que:
	///		Creï un Dictionary<string, int> per emmagatzemar noms d'estudiants i les seves edats.
	///		Afegeixi els següents valors:
	///		    "Marc" → 21
	///		    "Laura" → 19 
	///		    "Pau" → 22
	///		Mostri el diccionari per pantalla.
	///		Pregunti a l’usuari un nom i indiqui si existeix en el diccionari.
	///		Si el nom hi és, mostri la seva edat.
	///		Esborri "Laura" del diccionari.
	///		Iteri per totes les entrades i les mostri per pantalla.
	/// </summary>
	public static void Ex9()
    {
		Dictionary<string, int> estudiants = new Dictionary<string, int>
		{
			{ "Marc", 21 },
			{ "Laura", 19 },
			{ "Pau", 22 }
		};

		Console.WriteLine("Diccionari inicial:");
		CollectionTools.PrintCollection(estudiants, "anys");

		Console.Write("\nIntrodueix un nom per buscar: ");
		string nom = Console.ReadLine();

		if (estudiants.TryGetValue(nom, out int edat))
		{
			Console.WriteLine($"· {nom} existeix al diccionari amb {edat} anys.");
		}
		else
		{
			Console.WriteLine($"{nom} no es troba al diccionari.");
		}

		estudiants.Remove("Laura");
		Console.WriteLine("\nDespres d'eliminar 'Laura':");
		CollectionTools.PrintCollection(estudiants, "anys");
	}

	/// <summary>
	/// Donada una llista de números, escriu un programa que calculi la suma de tots els elements.
	/// </summary>
	private static void Ex14()
	{
		List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };

		Console.Write("Calcul de la suma de la llista: ");
		Console.WriteLine(string.Join(", ", numeros.Select(num => num.ToString())));

		int suma = numeros.Aggregate((x, y) => x + y);

		Console.WriteLine($"La suma de tots els elements es: {suma}");

	}

	/// <summary>
	/// Donat un array de strings, converteix-ho en una llista i mostra els elements de la llista.
	/// </summary>
	private static void Ex16()
	{
		string[] arrayStrings = { "Hola", "Mon", "C#", "Llistes" };

		// Convertir l'array en una llista de dos formes diferents
		List<string> llistaStrings = new List<string>(arrayStrings);

		List<string> llistaStrings2 = arrayStrings.ToList();

		llistaStrings.ForEach(str => Console.WriteLine(str));
	}

	/// <summary>
	/// Crea un diccionari que emmagatzemi informació sobre empleats (nom i salari) i mostri la informació.
	/// </summary>
	private static void Ex17()
	{
		Dictionary<string, decimal> empleats = new Dictionary<string, decimal>
		{
			{ "Joan", 2500.50m },
			{ "Maria", 3000.75m },
			{ "Pere", 2800.00m },
			{ "Anna", 3200.25m }
		};

		Console.WriteLine("Llista d'empleats i els seus salaris:");

		// Diccionari es IEnumerable, es pot iterar:
		foreach (var empleat in empleats)
		{
			Console.WriteLine($"Nom: {empleat.Key}, Salari: {empleat.Value}€");
		}
	}

	/// <summary>
	/// Donada una llista de números, elimina els elements que siguin majors que un valor específic.
	/// </summary>
	private static void Ex18()
	{
		List<int> numeros = new List<int> { 5, 10, 15, 20, 25, 30 };

		int llindar = 12;

		// Crear una nova llista filtrada
		List<int> llistaFiltrada = numeros.Where(num => num <= llindar).ToList();

		Console.WriteLine("Nova llista despres de filtrar:");

		llistaFiltrada.ForEach(str => Console.WriteLine(str));
	}

	/// <summary>
	/// Implementa una funció que validi si una cadena és un correu electrònic vàlid. Un correu electrònic vàlid ha de complir el seu format
	/// </summary>
	private static void Ex26()
	{
		Console.WriteLine(IsValidEmail("usuari@gmail.com"));  
		Console.WriteLine(IsValidEmail("usuari@gmail"));      
		Console.WriteLine(IsValidEmail("user.name@domain.org")); 
		Console.WriteLine(IsValidEmail("user@sub.domain.com")); 
		Console.WriteLine(IsValidEmail("user@@domain.com")); 
		Console.WriteLine(IsValidEmail("user@domain.")); 
	}

	static bool IsValidEmail(string email)
	{
		string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
		return Regex.IsMatch(email, pattern);
	}

	private static void Ex28()
	{
		string text = "Avui es el dia 12 del mes 02 de l'any 2024";

		List<int> numeros = ExtractNumbers(text);

		Console.WriteLine($"Numeros en el text: [{string.Join(", ", numeros)}]");
	}

	private static List<int> ExtractNumbers(string input)
	{
		List<int> numeros = new List<int>();
		string pattern = @"\d+";  // Cerca un o mes digits consecutius

		MatchCollection coincidencies = Regex.Matches(input, pattern);

		foreach (Match match in coincidencies)
		{
			numeros.Add(int.Parse(match.Value)); 
		}

		return numeros;
	}
}