olpt = "C:/Darren/TestingData/npmpackages/node_modules"
plpt = "D:/TestingData/pnpm/node_modules"
loadPack = plpt

var http = require('http');
var dt = require('./myfirstmodule');
var url = require('url');
var path = require('path')
var adr = 'http://localhost:8080/default.htm?year=2017&month=february&city=mumbai'
var fs = require('fs');
//var uc = require(`${loadPack}/uppercase`);
//var uc = require('uppercase');
//var formidable = require(`${loadPack}/formidable`);
var formidable = require('formidable');
var uc = require('uppercase');
//const ld = require('lodash');


const hostname = '127.0.0.1';
const port = 8082;
fslocation = 'C:\\Darren\\TestingData\\testingFiles\\'
var q = url.parse(adr,true)

var fs = require('fs');

var rs = fs.createReadStream('./demofile1.html');
rs.on('open', function () {
  console.log('The file is open');
});

http.createServer(function (req, res) {
  
  if(req.url == '/servefile'){
  var q = url.parse(req.url,true);
  var filename = "." + q.pathname;
  fs.readFile(filename,function(err, data){
    if (err) {
      res.writeHead(404, {'Content-Type': 'text/html'});
      console.log(q.pathname); console.log(req.url); console.log(req.hostname);
      return res.end("404 Not Found");      
    } 
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write(data);
    return res.end();
    console.log(q.pathname); console.log(req); console.log(q.query);
  })};


  if (req.url == '/aboutus') {
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write('<h1>Page About Us</h1>');
    res.end()
    }

  if (req.url == "/") {
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write("The date and time are currently: " + dt.myDateTime() + "requested via URL: " + req.url);
    res.write("<HTML><BODY><br>-------------------------<br><BODY><HTML>");
    var q = url.parse(req.url, true).query;
    var txt = q.year + " " + q.month;
    res.write(txt);
    res.end();
   }

   if (req.url == "/html") {
    fs.readFile('demofile1.html', function(err, data) {
      res.writeHead(200, {'Content-Type': 'text/html'});
      res.write(data);
      return res.end();
    });
  }

  if (req.url == "/createfile") {
    fs.appendFile(`${fslocation}mynewfile1.txt`, 'Hello Denver!', function (err) {
      if (err) throw err;
      console.log('Saved!');
      res.end();
    });
  }

//form upload
if (req.url == "/fileupload") {
  if(req.method == 'POST'){
    var form = new formidable.IncomingForm();
    form.parse(req, function (err, fields, files){
      var oldpath = files.filetoupload[0].filepath;
      //var newpath = path.join('C:/Darren/TestingData/testingFiles/',files.filetoupload.originalFilename);
      //let rawData = fs.readFileSync(oldPath)
      console.log(files,oldpath);
      // fs.writeFile(newpath,rawData,function (err){
      //   if (err) throw err;
      //   res.write("File Uploaded and moved!");
      //   res.end();
      // });      
  })} else {
        fs.readFile('fileupload.html', function(err, data) {
        res.writeHead(200, {'Content-Type': 'text/html'});
          res.write(data);
        return res.end();
        }
)}};
    console.log(`Server running at http://${hostname}:${port}/`)
}).listen(port,hostname);