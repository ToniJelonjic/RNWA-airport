<?php

if(!extension_loaded("soap")){
  dl("php_soap.dll");
}

ini_set("soap.wsdl_cache_enabled","0");

$server = new SoapServer("convert.wsdl");

function convert($num,$cur1,$cur2){
  if($num == ""){
    return "You must enter amount!";
  }
    if($cur1=="EUR" AND $cur2=="BAM"){
      return $num*1.94 . " BAM";
    }else if($cur1=="BAM" AND $cur2=="EUR"){
      return $num/1.94 . " EUR";
    }else if($cur1=="BAM" AND $cur2=="USD"){
      return $num/1.81 . " USD";
    }else if($cur1=="USD" AND $cur2=="BAM"){
      return $num*1.81 . " BAM";
    }

}

$server->AddFunction("convert");
$server->handle();
?>