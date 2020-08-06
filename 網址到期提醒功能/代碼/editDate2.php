<?php

session_start();
// 登入判斷
if(!isset($_SESSION['username'])){
    echo "<script>alert('請先登入');window.location.href='login.php'</script>";
} 
//宣告網站到期剩餘天數陣列
$expiryDateArray = [];

//此變量用來動態設置class名稱
$webId = 0;

//導入config
include_once('config.php');

//查詢網站資訊
$query1 = "select * from domain order by domain ;";

//執行mysql語句
$result1 = $pdo->prepare($query1);
$result1->execute();

?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>網域監控</title>
    <script  type="text/javascript" src="jquery-3.4.1.min.js"></script>
    <style type="text/css">
        th {
            color: #0a6999;

        }
        a {
            text-decoration : none;
        }
        .warning {
            background-color : #FFFF00;
        }

    </style>
</head>
<body>

<h3 align="center">修改期限</h3>

<div>

    <table align="center" border="2px" width="600" cellpadding="10" bgcolor="#fff8dc">
        <tr>
            <th>ID</th>
            <th>網域</th>
            <th>網址</th>
            <th width="150">期限</th>
        </tr>
        <!--使用while語句，列出網址資訊-->
        <?php while($row=$result1->fetch(PDO::FETCH_ASSOC)){  
            // 計算網頁到期天數並存入$expiryDateArray[]陣列
            $now = date_create();
            $expiryDate = date_create($row["expiry_date"]);
            $diff = date_diff($now, $expiryDate)->format("%R%a");
            $expiryDateArray[] = $diff;

        ?>
        <!--列出網址資訊-->
        <tr >
            <td><?= $row["id"];?></td>
            <td><?= $row["domain"];?></td>
            <td class='web<?= $webId; ?>'><?= $row["web"];?></td>
            <td class='web<?= $webId++; ?>'><?= $row["expiry_date"];?></td>

        </tr>
        <?php  } ?>
    </table>
    <br>
    <div align="center">
        <form method="post" action="updateDate.php" onsubmit="">

            <div style="display: flex;justify-content: center; ">
            <div>ID<input id="id" name="id" class="input"  type="text" value=""></div>
            
            <div>網址<input id="web" name="web" class="input"  type="text" value=""></div>
           
            <div>期限<input id="date" name="date" class="input"  type="text" value=""></div>
            </div>
            <br>
            <div><input name="submit" type="submit" ></div>
        </form>
    </div>           

</div>

</body>
</html>
<?php
// 將剩餘天數陣列轉成json格式
$jsonArray = json_encode($expiryDateArray, true);
 ?>


<script type="text/javascript">
    //此方法將快到期的網站添加警告樣式
    $(document).ready(function(){
        var array = JSON.parse('<?= $jsonArray?>');

        for(var a = 0; a<array.length ; a++ ) {
            if(array[a] <= 2) {
            $(".web"+a).addClass("warning");
            
            }
        }

    });

</script>
