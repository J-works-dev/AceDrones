# AceDrones
Assessment for C# in TAFE

The program functionality must satisfy the following criteria:
1. The program loads the drone information from a binary file called drones.dat when the program starts
into an appropriate single array structure. Array size of 20.
2. The program loads the customer information from a binary file called customers.dat when the program
starts into an appropriate single array structure. Array size of 20.
3. The program loads the transaction information from a binary file called transactions.dat when the
program starts into an appropriate 2D array structure.
4. When the Drone ADD button is clicked,
a The information in the textboxes is checked to verify the data type,
b If information is in too many or too few input boxes then an error message is generated,
c If the information is correct then a Drone object is created and the object is added to the array
structure and the serialNumber, engineConfiguration and price are displayed in the listbox. Add
hyphens between data items.
d The array is sorted by serialNumber in ascending order. Use a simple Bubble sort algorithm,
when a record is swapped ensure the index/object is passed by reference to a separate swap
method.
e Once the new drone has been added to the array and displayed in the listbox the input text boxes
are cleared.
5. When the Customer ADD button is clicked,
a The information in the textboxes is checked to verify it is present,
b If information is not present then a dialog popup is generated with a request to generate a
default customer using a yes/no option,
c If the user selects YES then a default customer is added (refer Case Study info and Figure 1.)
d If the user selects NO then no further action is taken,
e When all the correct information is present a Customer object is created and the object is added
to the array structure and all the data is displayed in the listbox.
f Once the new customer has been added to the array and displayed in the listbox the input text
boxes are cleared.
6. When a record in either of the two upper listboxes (Drone or Customer) is clicked, the information
relating to that record is to be added to the correct Drone and Customer textboxes. The appropriate
information is also added to the textboxes under Transaction, (refer: red arrows in Figure 1).
7. Before the Transaction ADD button is clicked the user must first select a customer and drone. This
action will populate the customerID and serialNumber textboxes in the transactions groupbox (ensure
these textboxes are read only).
a The information in the input textboxes is checked to verify all data is present, otherwise generate
an error message,
b If all data is present a Transaction object is created and the object is added to the 2D array
structure and the information is added to the listbox. Use a tab delimiter between the data items
in the listbox.
AT 2
6
c When a record in the transaction listbox is clicked the transaction information is filled into the
remaining transaction input text boxes, and the appropriate Book and Customer records are
selected in the upper listboxes. This should autofill the upper textboxes.
8. If the user double clicks the serialNumber input textbox it will clear the all the input textboxes
associated with the Book and allow a new book to be entered.
9. If the user double clicks the customerID input textbox it will clear the all the input textboxes associated
with the Customer and allow a new customer to be entered.
10. To search for a customer the user will enter text into the customerID input textbox. The user then right
clicks the customerID input textbox and a context menu will appear with a search button. If the record
is found the other fields will be populated. If the record is not found generate an error message box.
The search algorithm must use the simple built-in binary search.
Figure 2
11. If the user double clicks the transactionID input textbox it will clear the all the input textboxes
associated with the Transaction and allow a new transaction to be entered.
12. All data should be written back to the three binary files when the form closes.
13. Add code comments to all Methods and Classes. Ensure all key aspects of your code are fully
documented (do not use complex or technical terms)
14. Add realistic data to test the application
o 8 customers (max of 3 unknown),
o 15 drones,
o 10 transactions
15. Each of the major controls should have a tool tip text attached, refer Figure 3.
