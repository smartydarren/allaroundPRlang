var http = require('http');
var dt = require('./myfirstmodule');
var url = require('url');

http.createServer(function (req, res) {
  res.writeHead(200, {'Content-Type': 'text/html'});
  res.write("The date and time are currently: " + dt.myDateTime() + "requested via URL: " + req.url);
  res.write("<HTML><BODY><br>-------------------------<br><BODY><HTML>");
  var q = url.parse(req.url, true).query;
  var txt = q.year + " " + q.month;
  res.write(txt);
  res.end();
}).listen(8082);