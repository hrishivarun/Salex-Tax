1)  The exempted items must be in the list of the exempted items stored in source code,
    i.e food, medicine or book. Any other item name will not be exempted from tax.




2)  Check if input is null or not and add exception handling




    `
    Console.WriteLine("\nEnter price of item: ");
    double itemPrice = Convert.ToDouble(Console.ReadLine());

    bool isImported = false;
    Console.WriteLine("\nIs it imported(y/n)---(Default: y) : ");
    string import = (Console.ReadLine()).ToLower();
    if(import == "\n" || import == "y")
    {
      isImported = true;
    }

    Console.WriteLine("\nEnter total number of items: ");
    int itemCount = Convert.ToInt32(Console.ReadLine());
    `

    