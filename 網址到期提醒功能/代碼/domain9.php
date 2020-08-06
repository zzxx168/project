<?php

$expiryDateArray = [];
$i = 0;  
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

<h3 align="center">網域監控</h3>

<div>
    <!-- <form align="center" id='form' method="post" action="" > -->
    <table align="center" border="2px" width="600" cellpadding="10" bgcolor="#fff8dc">
        <tr>
            <th>網域</th>
            <!--                <th>編號</th>-->
            <th>網站</th>
            <th width="200">期限</th>
            <th width="200">操作</th>
        </tr>
        <!--插入php標籤並使用while語句，打印圖書資訊-->
        <?php while($rows=$result1->fetch(PDO::FETCH_ASSOC)){  
            $now = date_create();
            $expiryDate = date_create($rows["expiry_date"]);
            $diff = date_diff($now, $expiryDate)->format("%R%a");
            $expiryDateArray[] = $diff;


        ?>
        <tr >
            
            <td><?= $rows["domain"];?></a></td>
            <td class='web<?= $i++; ?>'><a target="_blank" href="http://<?= $rows["web"];?>"><?= $rows["web"];?></a></td>
            <td><?= $rows["expiry_date"];?></td>
            <!--設定編輯和刪除按鈕，使用?id方式傳遞id值-->
            <td>
                <button value="<?php echo $rows['id'] ?>" onclick="location.href='editDate.php?id=<?php echo $rows['id'] ?>'">修改期限</button>
                <span onclick="return confirm('確定刪除?')">
                    <button value="<?php echo $rows['id'] ?>" onclick="location.href='deleteWeb.php?id=<?php echo $rows['id'] ?>'">移除</button>
                </span>
            </td>
        </tr>
        <?php  } ?>
    </table>
    <p></p>
    <div align="center"><a href="addWeb.html">
    <button >新增網站</button></a>
    </div>            
    <!-- </form> -->
    <!--獲取總條數-->
<!--    <p align="center"><?php echo "總計".$sum."樣菜色" ?></p>-->
</div>

</body>
</html>
<?php
echo "<pre>";
var_dump($expiryDateArray);
if($expiryDateArray[0] < 0) {
    echo "$expiryDateArray[0]是負數";
   } else {
    echo "$expiryDateArray[0]";
   }

$jsonArray = json_encode($expiryDateArray, true);
 ?>


<script type="text/javascript">

    // $(document).ready(function(){
    //     var array = JSON.parse('<?= $jsonArray?>');

    //     // alert(array);
    //     for(var a = 0; a<array.length ; a++ ) {
    //         if(array[a] <= 2) {
    //         $(".web"+a).addClass("warning");
            
    //         }
    //     }

    // });

</script>
