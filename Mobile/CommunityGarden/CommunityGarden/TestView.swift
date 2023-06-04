////
////  TestView.swift
////  CommunityGarden
////
////  Created by Станислав Голя on 04.06.2023.
////
//
//import Foundation
//import Alamofire
//import SwiftUI
//
//struct Test {
//
//
//        
//    static func login(email: String, password: String) {
//        let parameters: Parameters = [
//            "email": email,
//            "passwordHash": password
//        ]
//        let string = email + "@@@" + password
//        AF.request("https://communitygarden.azurewebsites.net/api/LoginApi/\(string)")
//            .validate(statusCode: 200..<300)
//            .responseDecodable(of: User.self) { response in
//                switch response.result {
//                case .success(let apiResponse):
//                    // Login successful, handle the response
//                    print(apiResponse.id)
//                    print(apiResponse.secondName)
//                    print(apiResponse.bio)
//                    // Access other properties of ApiResponse
//
//                case .failure(let error):
//                    // Login failed, handle the error
//                    print("Login failed: \(error)")
//                }
//            }
//    }
//
//}
