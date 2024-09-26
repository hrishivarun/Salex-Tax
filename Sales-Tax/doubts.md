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

    


Input 1:
1 book at 12.49
1 music CD at 14.99
1 chocolate bar at 0.85

Input 2:
1 imported box of chocolates at 10.00
1 imported bottle of perfume at 47.50

Input 3:
1 imported bottle of perfume at 27.99
1 bottle of perfume at 18.99
1 packet of headache pills at 9.75
1 box of imported chocolates at 11.25
