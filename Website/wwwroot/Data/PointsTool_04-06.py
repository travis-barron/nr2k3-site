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
        if cells[7].string.strip() != 'POINTS':
            finish = cells[0].string.strip()
            start = cells[1].string.strip()
            carNum = cells[2].string.strip()
            driver = cells[3].string.replace(',', '').strip()
            laps = cells[5].string.strip()
            led = re.sub("[^0-9]", "", cells[6].string.strip())
            points = cells[7].string.strip()
            if int(finish) == 1:
                points = str(int(points) + 5)
            status = cells[8].string.strip()
        else:
            finish = 'F'
            start = 'S'
            carNum = '#'
            driver = 'DRIVER'
            laps = 'LAPS'
            led = 'LED'
            points = 'POINTS'
            status = 'STATUS'
        
        entry = (finish + "," + 
                start + "," + 
                carNum + "," +
                driver + "," +
                laps + "," +
                led + "," +
                points + "," +
                status + "\n")
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