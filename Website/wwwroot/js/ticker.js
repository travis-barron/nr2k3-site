function GetTop10(year) {
    $.ajax({
        url: '/Home/GetTop10?year=' + year,
        success: function (data) {
            results = data;
            let count = 1;
            results.forEach(function (elem) {

                let li = $('<li style="display: inline; color: #fff; padding: 6px;"></li>');
                console.log(elem);
                li.append(count + '. ');
                li.append(elem.name + ' - ');
                li.append(elem.points + ' pts ');
                li.append('(' + (elem.points - results[0].points) + ') ');
                //li.append($('img').attr('src', '/Images/Icons/' + elem.number + '.png').css('max-width', '20px'));
                $('#top10-list').append(li);
                count++;
            });
        }
    })
}