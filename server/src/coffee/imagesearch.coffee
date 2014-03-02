http = require("http")
Q = require("Q")

cx = '017716653312651474242%3Af1wy4gpl-78'
key = 'AIzaSyAwNFSNnkwld4r-GF3yYcaH0DBkpbck6sw'
num = 1
safe = 'high'
searchType = 'image'

baseUrl = 'https://www.googleapis.com/customsearch/v1?'

#https://www.googleapis.com/customsearch/v1?q=pineapple&cx=017716653312651474242%3Af1wy4gpl-78&num=2&safe=medium&searchType=image&key=AIzaSyAwNFSNnkwld4r-GF3yYcaH0DBkpbck6sw
exports.findImage = (keyword) ->
	deferred = Q.defer()

	console.log("In here yo!")
	url = "#{baseUrl}q=#{keyword}&cx=#{cx}&key=#{key}&num=#{num}&safe=#{safe}&searchType=#{searchType}"
	http.get url, (data) ->
		result = data.items[0]
		imageLink = items.link

		deferred.resolve(imageLink)

	return deferred.promise