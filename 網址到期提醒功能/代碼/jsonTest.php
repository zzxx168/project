<?php
// $jsontest = '[
//   {
//     "domain" : "GoDaddy",
//     "web" : [
//       {
//        "name" : "http://8iim.com", 
//        "date" : "2020-10-9"
//       },
//       {
//        "name" : "http://cf.8iim.com", 
//        "date" : "2020-10-9"
//       }
//     ]
//   },
//   {
//     "domain" : "Namecheap",
//     "web" : [
//       {
//        "name" : "https://www.gamer16888.com/", 
//        "date" : "2020-10-9"
//       },
//       {
//        "name" : "http://dd-in.com", 
//        "date" : "2020-10-9"
//       },
//       {
//         "name" : "http://ezcard168.com",
//         "date" : "2020-10-9"
//       }
//     ]
//   },
//   {
//     "domain" : "hinet",
//     "web" : [
//       {
//        "name" : "http://solgar.com.tw/", 
//        "date" : "2020-10-9"
//       }
//     ]
//   }
  
// ]';

// $testObject1 = json_decode($jsontest);
// $testObject2 = json_decode($jsontest, true);
// $a = json_encode($testObject1); 
// $b = json_encode($testObject2); 
// echo "<pre>";
// // var_dump($testObject1);
// // var_dump($a);
// // var_dump($b);
// // echo strtotime("2009-10-21").'<br>';
// // echo strtotime("2009-10-21 16:00:10")."<br>";
// $date1 = date('Y-m-d',strtotime("2009-10-21"));

// // echo $date1."<br>";s
// // $date2 = date("2013-12-12");
// // echo $date2;
// $str = "2020-8-5";
// $date8=date_create($str);
// $date9=date_create();

// $now = date_create();
// $expiryDate = date_create("2019-10-21");
// $diff2 = date_diff($now, $expiryDate)->format("%R%a");

// // echo "opud";


// // echo date_format($date8,"Y/m/d");
// // $diff=date_diff($date1,$date2);
// // echo $diff->format("%R%a days");

// // $date3=date_create("2013-03-15");
// // $date4=date_create("2013-12-12");
//  $diff=date_diff($date8,$date9)->format("%R%a");
//  echo $diff2.'<br>';
// if($diff2>0) {
// 	echo "恭喜";
// } else {
// 	echo "殘念";
// }

// $array5 = [1=>["Ddomain" => "godaddy", "web" => "cf.8iim.com", "date" => "2021-08-21"]];

include_once('config.php');

$query1 = "select * from domain order by id ;";

$result1 = $pdo->prepare($query1);
$result1->execute();
$rows1=$result1->fetchAll(PDO::FETCH_ASSOC);
$domainArray =[];
foreach ($rows1 as $value) {
  $id = $value["id"];
  $domain = $value['domain'];
  $web = $value['web'];
  $expiry_date = $value['expiry_date'];
  // $domainArray[$id] = ["domain" =>$value['domain'], "web" => $value['web'], "expiry_date" => $value['expiry_date']];
 $domainArray[$id] = [$value['domain'], $value['web'], $value['expiry_date']];

    // $domainArray[ "sre" => "5"];
}
$jsonstr = json_encode($domainArray);
// $domainArray[$value['domain']] = $value["domain_web"];

// $array5 = [1=>["Ddomain" => "godaddy", "web" => "cf.8iim.com", "date" => "2021-08-21"]];



echo "<pre>";
var_dump($domainArray);
var_dump($jsonstr);
// echo count($domainArray);
// var_dump($array5);