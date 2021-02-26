import { Component, OnInit } from '@angular/core';
import { Profile } from '@models/profile.model';
import { NetworkService } from '@services/network.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  public entries: Profile[];
  constructor(private network: NetworkService) { }
  ngOnInit() { this.network.getData<Profile[]>('profiles').then(result => this.entries = result); }
}
