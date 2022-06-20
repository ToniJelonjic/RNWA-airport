<?php
  function call($controller, $action) {
    require_once('controllers/' . $controller . '_controller.php');

    switch($controller) {
      case 'pages':
      $controller = new PagesController();
      break;
	  case 'airport_reachable':
      require_once('models/airport_reachable.php');
		  $controller = new AirportReachableController();
      break;
	  case 'airline':
      require_once('models/airline.php');
		  $controller = new AirlineController();
      break;
    case 'airport':
      require_once('models/airport.php');
      $controller = new AirportController();
      break;
    }

    $controller->{ $action }();
  }

  $controllers = array('pages' 		=> ['home', 'error'],
            'airport_reachable' 		=> ['index', 'add', 'edit'],
					  'airline' => ['index', 'add', 'edit'],
					  'airport' 	=> ['index', 'add', 'edit']);

  if (array_key_exists($controller, $controllers)) {
    if (in_array($action, $controllers[$controller])) {
      call($controller, $action);
    } else {
      call('pages', 'error');
    }
  } else {
    call('pages', 'error');
  }
?>