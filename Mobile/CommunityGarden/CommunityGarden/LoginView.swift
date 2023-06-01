//
//  LoginView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 30.05.2023.
//

import SwiftUI

struct LoginView: View {
    @State private var email = ""
    @State private var password = ""
    @State private var isKeepsSigned = false
    @State private var goToGardenView = false
    @State private var goToGoogleAuthView = false
    var body: some View {
        NavigationView{
            VStack{
                HStack{
                    Text("Welcome back. Enter your credentials to access your account")
                        .foregroundColor(.gray)
                        .font(.callout)
                    Spacer()
                }
                Group{
                    Spacer()
                    Spacer()
                }
                Group{
                    TextField("Email Adress", text: $email)
                        .font(.title2)
                    SecureField("Password", text: $password)
                        .font(.title2)
                    HStack{
                        NavigationLink("Forgot password?", destination: ForgotPasswordView())
                            .font(.callout.bold())
                            .padding(.horizontal,5)
                        Spacer()
                    }
                    HStack{
                        Toggle( isOn: $isKeepsSigned, label: {
                            Text("Keep me signed in")
                                .font(.callout)
                                .foregroundColor(.black)
                        })
                            .padding(5)
                            .font(.title2)
                            .toggleStyle(iOSCheckboxToggleStyle())
                        Spacer()
                    }
                }
                Spacer()
                NavigationLink(destination: GardensView(), isActive: $goToGardenView) {EmptyView()}
                Button{
                    self.goToGardenView = true
                } label: {
                    Text("Continue")
                        .frame(maxWidth: .infinity)
                        .font(.title2)
                }
                .buttonStyle(.borderedProminent)
                
                Group{
                    
                    Text("or sign up with")
                        .foregroundColor(.gray)
                        .font(.callout)
                        .padding(.bottom,5)
                    
                    
                    NavigationLink(destination: GoogleAuthView(), isActive: $goToGoogleAuthView) {EmptyView()}
                    Button{
                        self.goToGoogleAuthView = true
                    }label: {
                        Label{
                            Text("Google")
                                .font(.title2)
                        } icon:{
                            Image("googleLogo")
                                .resizable()
                                .frame(width: 30, height: 30)
                                .environment(\.colorScheme, .dark)
                            
                        }
                        .frame(maxWidth: .infinity)
                    }.buttonStyle(.bordered)
                        .foregroundColor(.black)
                    Spacer()
                    HStack{
                        Text("Don’t have an Account?")
                            .font(.body.bold())
                        NavigationLink(destination: RegistrationView()){
                            Text("Sign up here")
                                .font(.body.bold())
                        }
                    }
                }
                Spacer()
                Spacer()
            }
            .textFieldStyle(.roundedBorder)
            .padding(10)
            
            
            .navigationTitle("Login")
            .navigationBarTitleDisplayMode(.large)
        }
    }
    func verifyCredentials () -> Void{
    }
    func googleLogin () -> Void{
    }
}

struct LoginView_Previews: PreviewProvider {
    static var previews: some View {
        LoginView()
    }
}
