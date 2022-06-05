const { GraphQLObjectType, GraphQLInt } = require('graphql');

const AirplaneType = new GraphQLObjectType({
  name: 'Airplane',
  fields:() => (
    {
      airplane_id: { type: GraphQLInt },
      capacity: { type: GraphQLInt },
      type_id: { type: GraphQLInt },
      airline_id: { type: GraphQLInt }
    }
  ) 
});

module.exports = AirplaneType;