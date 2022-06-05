const { GraphQLObjectType } = require('graphql');

const fieldsUser = require('./user');
const fieldsUsers = require('./users');
const fieldsPosts = require('./posts');
const fieldsAirplaneTypes = require('./airplanetypes');
const fieldsAirplaneType = require('./airplanetype');

const Query = new GraphQLObjectType({
  name: 'Query',
  fields: {
    // Query one user
    user: fieldsUser,
    // Query all users
    users: fieldsUsers,
    // Query all posts
    posts: fieldsPosts,
    // all airplanetypes
    airplanetypes: fieldsAirplaneTypes,
    // one airplanetype
    airplanetype: fieldsAirplaneType
  }
});

module.exports = Query;