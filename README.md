# name sorter

This is a .Net Core Version 7 Console Application.

## Goal

#### Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person may have. A name must have at least 1 given name and may have up to 3 given names.

#### Example Usage

#### Given a a file called unsorted-names-list.txt containing the following list of names

Janet Parsons

Vaughn Lewis

Adonis Julius Archer

Shelby Nathan Yoder

Marin Alvarez

London Lindsey

Beau Tristan Bentley

Leo Gardner

Hunter Uriah Mathew Clarke

Mikayla Lopez

Frankie Conner Ritter


#### Result

Marin Alvarez

Adonis Julius Archer

Beau Tristan Bentley

Hunter Uriah Mathew Clarke

Leo Gardner

Vaughn Lewis

London Lindsey

Mikayla Lopez

Janet Parsons

Frankie Conner Ritter

Shelby Nathan Yoder



#### Steps to execute

```
C:>..\..\Publish> name-sorter ./unsorted-names-list.txt

```

### File path (unsorted-names-list.txt and sorted-names-list.txt file)

The files stored in **Document** folder

#### Whats happening background

* Read the unsorted-names-list.txt file and sort

* Store the sorted names in a file in the working directory called sorted-names-list.txt.

* read the sorted-names-list.txt and show the sorted name in console

