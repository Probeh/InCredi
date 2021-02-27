import { Component     , OnInit } from '@angular/core'
import { Profile                } from '@models/profile.model'
import { Results                } from '@models/results.model'
import { NetworkService         } from '@services/network.service'

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit {
  public profiles: Profile[];
  constructor(private network: NetworkService) { }
  ngOnInit() { this.network.getData<Profile[]>('profiles').then(result => this.profiles = result); }
  public getTotals(parentId: number) {
    this.network.getData<Results>(`profiles/${parentId}/totals`)
      .then(result => this.profiles.forEach(x => x.totals = x.parentId == parentId ? result : x.totals));
  }
}
