////
////  Requests.swift
////  CommunityGarden
////
////  Created by Станислав Голя on 04.06.2023.
////
//
//import Foundation
//import Alamofire
//
//class Requests:NetworkLayerProtocol{
//    func login(email: String, password: String) -> User?{
//        let string = email + "@@@" + password
//        var user: User?
//        AF.request("https://communitygarden.azurewebsites.net/api/LoginApi/\(string)")
//            .validate(statusCode: 200..<300)
//            .responseDecodable(of: User.self) { response in
//                switch response.result {
//                case .success(let apiResponse):
//                    // Login successful, handle the response
//                    user = apiResponse
//                    // Access other properties of ApiResponse
//                    
//                case .failure(_):
//                    // Login failed, handle the error
//                    user = nil
//                }
//            }
//        return user
//    }
//}
