import { Component, OnInit } from '@angular/core';
import {TemperatureService} from '../Services/temperature.service'

@Component({
  selector: 'app-temperature',
  templateUrl: './temperature.component.html',
  styleUrls: ['./temperature.component.css']
})
export class TemperatureComponent implements OnInit {

  constructor(private _service:TemperatureService) { }

  temperatureValue:number=0;
  oldvalue:string=null;
  currentValue:string=null;
  result:number;
  errorMessage:string="";
  displayError:boolean=false;
  defaultTemperatureValue:string;
  defaultTemperatureConverterValue:string;


  ngOnInit() {
    if( this.temperatureValue== 0)
    {
      this.temperatureValue= 0;
    }
  }

  SelectedTemperature(old: any) {

    if(this.temperatureValue == undefined)
    {  
        this.temperatureValue= 0;
    }
  

  this.oldvalue= old;      

  if(this.oldvalue!="0" || this.currentValue!="0")
  {        
    this.TemperatureConvertCal(this.temperatureValue,this.oldvalue,this.currentValue);
  }

}



TemperatureConverter(tempConvertValue: any) {

  if(this.temperatureValue == undefined)
  {  
      this.temperatureValue= 0;
  }
  

  this.currentValue= tempConvertValue; 

  if(this.oldvalue!="0" || this.currentValue!="0") 
  {
      this.TemperatureConvertCal(this.temperatureValue,this.oldvalue,this.currentValue);
  }
}

TemperatureConvertCal(tempValue:number,oldValue:string,currentValue:string)
  {
    
    this._service.GetTemperature(tempValue,oldValue,currentValue).subscribe(data=>
      {        
        this.result = data;     
        this.displayError = false;         
      },
      ($error) => {        
                                
        this.errorMessage = $error.error;           
        this.displayError = true;     
      }
      );   
  }

  TemperatureValueChange(temperatureValue:number)
{
  if(this.temperatureValue == undefined || this.temperatureValue.toString() == "")
  {  
      this.temperatureValue= 0;
  }
  
  

  if((this.oldvalue!=null) || (this.currentValue!=null))
  {    
    
    this.TemperatureConvertCal(this.temperatureValue,this.oldvalue,this.currentValue);    
    
  }
}



}
