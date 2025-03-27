import requests
import json

url = "http://localhost:5009/api/destinations/new"

com=[
    # combinacion 1
    {   "questionOptionIds": [1, 7, 15, 19, 26, 31],
        "firstCityId": 1,
        "secondCityId": 20 },
    # combinacion 2
    {   "questionOptionIds": [1, 7, 14, 21, 25, 31],
        "firstCityId": 2,
        "secondCityId": 21 },
    # combinacion 3
    {   "questionOptionIds": [1, 8, 14, 19, 26, 32],
        "firstCityId": 3,
        "secondCityId": 22 },
    # combinacion 4
    {   "questionOptionIds": [2, 9, 13, 20, 26, 31],
        "firstCityId": 4,
        "secondCityId": 23 },
    # combinacion 5
    {   "questionOptionIds": [2, 8, 14, 21, 26, 33],
        "firstCityId": 5,
        "secondCityId": 24 },
    # combinacion 6
    {   "questionOptionIds": [2, 9, 13, 19, 26, 32],
        "firstCityId": 6,
        "secondCityId": 25 },
    # combinacion 7
    {   "questionOptionIds": [3, 8, 14, 19, 26, 33],
        "firstCityId": 7,
        "secondCityId": 26 },
    # combinacion 8
    {   "questionOptionIds": [3, 8, 15, 21, 25, 31],
        "firstCityId": 8,
        "secondCityId": 27 },
    # combinacion 9
    {   "questionOptionIds": [3, 9, 14, 19, 26, 32],
        "firstCityId": 9,
        "secondCityId": 28 },
    # combinacion 10
    {   "questionOptionIds": [1, 7, 13, 20, 26, 31],
        "firstCityId": 10,
        "secondCityId": 29 },
    # combinacion 11
    {   "questionOptionIds": [2, 9, 14, 21, 26, 33],
        "firstCityId": 11,
        "secondCityId": 30 },
    # combinacion 12
    {   "questionOptionIds": [1, 8, 15, 21, 25, 33],
        "firstCityId": 12,
        "secondCityId": 31 },
    # combinacion 13
    {   "questionOptionIds": [3, 8, 13, 19, 25, 32],
        "firstCityId": 13,
        "secondCityId": 32 },
    # combinacion 14
    {   "questionOptionIds": [1, 8, 14, 20, 26, 31],
        "firstCityId": 14,
        "secondCityId": 33 },
    # combinacion 15
    {   "questionOptionIds": [2, 8, 13, 21, 27, 31],
        "firstCityId": 15,
        "secondCityId": 34 },
    # combinacion 16
    {   "questionOptionIds": [3, 7, 14, 19, 26, 33],
        "firstCityId": 16,
        "secondCityId": 35 },
    # combinacion 17
    {   "questionOptionIds": [1, 7, 14, 19, 26, 32],
        "firstCityId": 17,
        "secondCityId": 36 },
    # combinacion 18
    {   "questionOptionIds": [2, 9, 15, 21, 26, 33],
        "firstCityId": 18,
        "secondCityId": 37 },
    # combinacion 19
    {   "questionOptionIds": [3, 8, 14, 20, 26, 32],
        "firstCityId": 19,
        "secondCityId": 38 }
]


for c in com:
    payload = json.dumps(c)
    headers = {
      'Content-Type': 'application/json'
    }

    print(payload)

    response = requests.request("POST", url, headers=headers, data=payload)

    print(response.text)  