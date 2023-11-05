import { Component } from '@angular/core';
import { UrlServiceService } from 'src/app/url-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private urlservice:UrlServiceService){

  }
  gotUrl:any =false;
  code:any=''
  urlShort:any={
    id:0,
    longUrl:'',
    shortUrl:'',
  }
  
  onSubmit(){
    this.urlservice.SendLongUrl(this.urlShort).subscribe({
      next: (res)=>{
        this.urlShort=res;
        this.code=this.urlShort.shortUrl;
        this.urlShort.shortUrl='';
        console.log("Success");
        this.gotUrl=true;
       },
      error: (err)=> {
        console.log(err);
        alert("try again");}
    })
  }
}
