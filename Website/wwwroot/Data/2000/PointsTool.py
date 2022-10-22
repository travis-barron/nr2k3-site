from bs4 import BeautifulSoup
import os
import re 

def extract_race_info(file, count):
    f = open(file, "r")
    output = open('./RaceResults/r' + str(count) + '.csv', 'w')
    soup = BeautifulSoup(f.read(), 'html.parser')
    race = soup.find(lambda tag: tag.name=='h3')
    table = soup.find(lambda tag: tag.name=='table' and tag.has_attr('id') and tag['id']=="race-standings")
    rows = table.findAll(lambda tag: tag.name=='tr')

    print(race.string.strip() + ' loaded')
    for row in rows:
        cells = row.findAll(lambda tag: tag.name=='td')            
        entry = (cells[0].string.strip() + "," + 
                cells[1].string.strip() + "," + 
                cells[2].string.strip() + "," +
                cells[3].string.replace(',', '').strip() + "," +
                cells[5].string.strip() + "," +
                re.sub("[^0-9]", "", cells[6].string.strip()) + "," +
                cells[7].string.strip() + "," +
                cells[8].string.strip() + "\n")
        output.write(entry)
    f.close()
    output.close()    

directory = './RaceResults'
count = 1

for file in os.listdir(directory):
    if file.endswith(".html"):
        print('\n')
        extract_race_info(directory + '/' + file, count)
        print('\n')
        count = count + 1



#print(rows)

#parser.feed('<html><head><title>Test</title></head>'
#            '<body><h1>Parse me!</h1></body></html>')