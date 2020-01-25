import { Component, Inject } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { SearchItem } from '../app.component';
import { FormControl } from '@angular/forms';
import {
  debounceTime,
  distinctUntilChanged,
  switchMap,
  tap,
  map
} from "rxjs/operators";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-search-component',
  templateUrl: './search.component.html'
})

export class SearchComponent {
  private loading: boolean = false;
  private results: Observable<SearchItem[]>;
  private searchField: FormControl;
  apiRoot: string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiRoot = baseUrl+'api/Search/TwoSearchEngines';
  }

  ngOnInit() {
    this.searchField = new FormControl();
    this.results = this.searchField.valueChanges.pipe(
      debounceTime(400),
      distinctUntilChanged(),
      tap(_ => (this.loading = true)),
      switchMap(term => this.search(term)),
      tap(_ => (this.loading = false))
    );
  }

  search(term: string): Observable<SearchItem[]> {
    let apiURL = `${this.apiRoot}?term=${term}`;
    return this.http.get<SearchItem[]>(apiURL).pipe(
      map(data => {
        return data.map(item => {
          return new SearchItem(
            item.url,
            item.type
          );
        });
      }, error => console.error(error))
    );
  }
}

