function GetTop10(year) {
    $.ajax({
        url: '/Home/GetTop10?year=' + year,
        success: function (data) {
            results = data;
            let table = $('#top10-list');
            let i = 0;
            let lead = 0;
            results.forEach(function (elem) {
                let row = $('<tr></tr>');
                row.append($('<td>' + (i + 1) + '</td>'));
                row.append($('<td>' + elem.name + '</td>'));               
                row.append($('<td>' + elem.points + '</td>'));
                row.append($('<td>' + (elem.points - lead) + '</td>'));
                table.append(row); 
                if (i == 0)
                {
                    lead = elem.points;
                }
                i++;
            });
        }
    })
}