import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class YoutubeService {
  baseUrl: string = 'https://www.googleapis.com/youtube/v3/videos';

  queryParameters = {
    key: 'AIzaSyDFFX3iXAAdFcpAn9-MsHqxnqaynCunr9I',
    part: 'snippet',
    part1: 'statistics',
    id: 'QIg4ZIXl1OI',
  };

  constructor(private http: HttpClient) {}

  getVideo(videoId: string) {
    return this.http.get(this.baseUrl + videoId);
  }
}
