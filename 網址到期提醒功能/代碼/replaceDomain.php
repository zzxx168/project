<?php
// 導入cofig
include_once('config.php');
//獲取備份id
$id=$_GET['id'];

$query1 = "select * from domain_backup where id = ? ;";
//執行mysql語句
$result1 = $pdo->prepare($query1);
$result1->execute([$id]);
$row = $result1->fetch(PDO::FETCH_ASSOC);

//將json格式轉回陣列
$domaiArray = json_decode($row["json"], true);
$domaiArray2 = json_decode($row["json2"], true);


//刪除原本資料表數據
$deleteSQL ="delete from domain";
$result3 = $pdo->prepare($deleteSQL);
$result3->execute();

$deleteSQL ="delete from domain_web";
$result3 = $pdo->prepare($deleteSQL);
$result3->execute();

//獲取陣列元素逐條存入資料表
foreach ($domaiArray as $key => $value) {
	$id = $key;
	$domain = $value[0];
	$web = $value[1];
	$date = $value[2];
	$query2 = "insert into domain values (?,?,?,?)";
	$result2 = $pdo->prepare($query2);
	$result2->execute([$id, $domain, $web, $date]);
}

foreach ($domaiArray2 as $key => $value) {
    $id = $key;
    $domain = $value[0];
    $web = $value[1];

    $query2 = "insert into domain_web values (?,?,?)";
    $result2 = $pdo->prepare($query2);
    $result2->execute([$id, $domain, $web]);
}

?>

<!-- 回到主頁 -->
<script>window.location.href='index.php'; </script>