const { GraphQLObjectType, GraphQLInt, GraphQLString, GraphQLList } = require('graphql');
const { dbQuery } = require('../database');
const AirplaneType = require('./Airplane.js');

const AirplaneTypeType = new GraphQLObjectType({
  name: 'AirplaneType',
  fields:() => (
    {
      type_id: { type: GraphQLInt },
      identifier: { type: GraphQLString },
      description: { type: GraphQLString },
      airplane: { 
        type: AirplaneType,
        resolve: async (post) => {
          let res = await dbQuery(`SELECT * FROM airplane WHERE type_id = ${parseInt(post.type_id)}`);
          return res[0];
        }
      }
    }
  ) 
});

module.exports = AirplaneTypeType;