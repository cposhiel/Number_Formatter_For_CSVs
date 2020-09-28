# Number_Formatter_For_CSVs
An application that formats Irish phone numbers from a CSV file to include their international code.

The user writes in the path of the csv file, followed by the destination path of a newly created formatted csv file. (The old file is left completely intact.)

The programme then asynchronously reads the contents of the file, formats all phone numbers to include an Irish international (eg. 087 => +35387) and writes them to the destination path.
