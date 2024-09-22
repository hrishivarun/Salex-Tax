# Sales-Tax

This is a console-based Sales Tax calculator program that takes in the details of purchased items, calculates the total cost including taxes, and generates a receipt.

## Example Usage

When you run the program, you will be prompted to input the details of items in your order and whether you wish to add more items or orders. After all inputs are provided, the program will display the receipt.


### To run the application, please run the following command in terminal from the root directory -
```
cd .\Sales-Tax\
dotnet run
```

### Example Input/Output

```
Welcome to our Receipt Controller!!!

Please items and their details!

Enter item details: 
1 book at 12.49

Add more items?(y/n)---(Default: y) : 
y

Enter item details: 
1 music CD at 14.99

Add more items?(y/n)---(Default: y) : 
n

Add more orders?(y/n)---(Default: y) : 
n

Receipts: - 

Receipt:
1 book: 12.49
1 music CD: 16.49
1 chocolate bar: 0.85
Sales Taxes: 1.50
Total: 29.83

```
