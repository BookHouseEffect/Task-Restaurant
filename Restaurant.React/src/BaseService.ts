import { env } from './Environment';

export default class BaseService {
  baseUrl: string = '';
  token: string = '';
  headers: any;

  constructor(token: string) {
    var url = env.API_URL;
    url.replace(/\/$/, '');
    this.baseUrl = url;

    this.token = token;
    this.headers = { 
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    }
  }

  httpGet(route: string) : Promise<Response> {
    return fetch(`${this.baseUrl}${route}`, { headers: this.headers })
      .then(response => {
        return response.json()
      });
  }

  httpPost(route: string, object: any): Promise<Response> {
    return fetch(`${this.baseUrl}${route}`, {
      method: "POST",
      body: JSON.stringify(object),
      headers: this.headers
    })
    .then(response => {
      return response.json()
    });
  }

  httpDelete(route: string): any {
    return fetch(`${this.baseUrl}${route}`, {
      method: 'DELETE',
      headers: this.headers
    }).then(response => {
      return response.text()
    });
  }
}