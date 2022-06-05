const { GraphQLObjectType } = require('graphql');
const insertAirplaneType = require('./insertAirplaneType');
const insertUser = require('./insertUser');

const Mutation = new GraphQLObjectType({
  name: 'mutation',
  fields: {
    // Insert a new user record
    insertUser: insertUser,
    // insert new airplanetype
    insertAirplaneType: insertAirplaneType
  }
});

module.exports = Mutation;
