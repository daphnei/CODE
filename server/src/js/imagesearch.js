// Generated by CoffeeScript 1.7.1
(function() {
  var Q, baseUrl, cx, http, key, num, safe, searchType;

  http = require("http");

  Q = require("Q");

  cx = '017716653312651474242%3Af1wy4gpl-78';

  key = 'AIzaSyAwNFSNnkwld4r-GF3yYcaH0DBkpbck6sw';

  num = 1;

  safe = 'high';

  searchType = 'image';

  baseUrl = 'https://www.googleapis.com/customsearch/v1?';

  exports.findImage = function(keyword) {
    var deferred, url;
    deferred = Q.defer();
    console.log("In here yo!");
    url = "" + baseUrl + "q=" + keyword + "&cx=" + cx + "&key=" + key + "&num=" + num + "&safe=" + safe + "&searchType=" + searchType;
    http.get(url, function(data) {
      var imageLink, result;
      result = data.items[0];
      imageLink = items.link;
      return deferred.resolve(imageLink);
    });
    return deferred.promise;
  };

}).call(this);
