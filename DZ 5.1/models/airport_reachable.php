<?php
    class AirportReachable  {
        public $airport_id;
        public $hops;


        public function __construct($airport_id = null, $hops) {
            $this->airport_id = $airport_id;
            $this->hops = $hops;
        }


        public static function getAllAirportReachables() {
            $airport_reachables = [];
            $db = Db::getInstance();
            $request = $db->query('SELECT * FROM airport_reachable');
                foreach($request->fetchAll() as $airp) {
                $airport_reachables[] = new AirportReachable($airp['airport_id'], $airp['hops']);
            }

            return $airport_reachables;
          }


          public static function findById($id) {
            $db = Db::getInstance();
            $id = intval($id);

            $request = $db->prepare('SELECT * FROM airport_reachable WHERE airport_id = :id');
            $request->execute(array('id' => $id));
            $airport_reachable = $request->fetch();
            
            if ($airport_reachable) {
                return new AirportReachable($airport_reachable['airport_id'], $airport_reachable['hops'], $airport_reachable['hops'], $airport_reachable['ModifiedDate']);
            } else {
                return [];
            }
          }


          public function editAirportReachableById($id, $newhops){
            $db = Db::getInstance();
            $id = intval($id);

            $sql = "UPDATE airport_reachable SET 'hops' = '$newhops') VALUES WHERE airport_id = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="AirportReachable updated!";
            } else {
                $rez="AirportReachable not updated!";;
            }
            
            return $rez; 
          }


          public function addAirportReachable($hops){
            $db = Db::getInstance();

            $sql = "INSERT INTO airport_reachable (`hops`) VALUES ('$hops')";

            if ($db->query($sql) == TRUE){
                $rez="AirportReachable added!";
            } else {
                $rez="AirportReachable not added!";;
            }
            
            return $rez; 
          }


          public static function deleteAirportReachableById($id) {
            $db = Db::getInstance();
            $sql = "DELETE FROM airport_reachable WHERE airport_id = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="AirportReachable deleted";
            } else {
                $rez="Deletion error!";;
            }
            
            return $rez; 
        }
    }
?>