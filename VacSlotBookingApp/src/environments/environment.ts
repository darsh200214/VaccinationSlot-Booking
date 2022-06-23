// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  JWT_TOKEN: 'BEDMGMT_JWT_TOKEN',
  REFRESH_TOKEN: 'BEDMGMT_REFRESH_TOKEN',
  UserId:'BEDMGMT_UserId',
  UserName: 'BEDMGMT_UserName',
  RoleName:'BEDMGMT_RoleName',
  apiBaseUrl: 'http://localhost:55244/api/v1/',
  Language:'BEDMGMT_Language',
  SubscriberDefaultPassword:'root1234',
  UserCode: 'BEDMGMT_UserCode',
  ProfilePic:'BEDMGMT_ProfilePic'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
