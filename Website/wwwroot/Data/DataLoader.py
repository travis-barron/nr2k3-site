import mysql.connector;

mydb = mysql.connector.connect(
    host="192.168.4.42",
    user="root",
    password="Secretary-Reply-Alike-Librarian-7",
    database="racing"
);

mycursor = mydb.cursor();

mycursor.execute("SHOW DATABASES");

for x in mycursor:
    print(x);