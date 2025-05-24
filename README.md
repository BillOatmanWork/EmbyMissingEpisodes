# EmbyMissingEpisodes
Detects if Ember server is missing any TV episodes

## Installation
- Decompress the proper file for your operating system into a folder. 

## Parameters (Case Insensitive)
- -ffmpegPath=Path to the ffmpeg executable.  Just the folder, the exe is assumed to be ffmpeg.exe or ffmpeg.
- -inFile=The video file the subtitles will be generated for.
- Optional: -nomerge  By default once the subtitle file is created, it is merged into a MKV container along with the video file. If this parameter is used, the MKV container will not be created and the subtitle file will not be deleted.
- Optional: -translate  If this is used, subtitles will be translated to English.  Do not use if the audio is already in English.
- Optional: -detectAudioLanguage Automatically detect the language of the audio. Set the audioLanguage parameter if this is false. Default false.
- Optional: -audioLanguage=<language>  Set this if detectAudioLanguage is false and the audio is not in english. English is the default.
- Optional: -language=The language of the audio and therefore the subtitles. en for example is english. This is used for the naming of the subtitles file. Default is none.
- Optional: -Model=<Language Model>  Options are Small/Medium/Large.  Bigger is better quality, but also slower. Default = Medium.
- Optional: -noRepair  Sometimes a recording will have audio errors that stop the processing.  By default, the app will attempt to make repairs.  Use of this flag aborts the repair and the app just fails.
- Optional: -noSDH Do not generate descriptive lines such as [grunting]. By default, the descriptive (SDH) subtitles will be included.
- Optional: -forceModelUpdate  Force the update of the Whisper model. If set, the model will be downloaded even if it already exists. Default: false.
- Optional: -shutDown  If set, the system will be shutdown when complete. Note that this likely only works on Windows.
  
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
