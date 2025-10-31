import requests
import json

url = "https://httpbin.org/post"
headers = {"Accept": "application/json", 'content-type': 'application/json'}
payload={"name": "darren"}

res = requests.post(url=url,headers=headers,json=payload)
print(res.text)

response_dict = json.loads(res.text)
print(response_dict["json"]["name"])

keysList = list(response_dict.keys())
print(keysList)