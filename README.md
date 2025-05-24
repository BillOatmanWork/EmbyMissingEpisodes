# EmbyMissingEpisodes
Detects if Ember server is missing any TV episodes

## Installation
- Decompress the proper file for your operating system into a folder. 

## Parameters (Case Insensitive)
- EmbyMissingEpisodes API_KEY urlORlocalhost port daysToCheck
- To get Emby api key go to dashboard>advanced>security and generate one
  
## Example
Run on the same server as Emby looking back 30 days.
```
EmbyMissingEpisodes <Emby Key> localhost 8096 30
``` 

Run on a different machine as Emby looking back 60 days.
```
EmbyMissingEpisodes <Emby Key> 123.0.1.1 8096 60
``` 

## Note
EmbyMissingEpisodes is CharityWare. If you like this program and find it of value, please consider making a
donation to a local charity that benefits children such as Special Olympics.
